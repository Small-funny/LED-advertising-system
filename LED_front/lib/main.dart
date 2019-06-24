import 'package:flutter/foundation.dart';
import 'package:web_socket_channel/io.dart';
import 'package:flutter/material.dart';
import 'package:web_socket_channel/web_socket_channel.dart';
import 'dart:typed_data';
import 'package:flutter/rendering.dart';
import 'dart:ui';
import 'package:dio/dio.dart';
import 'package:flutter_swiper/flutter_swiper.dart';
import 'package:flutter_ijkplayer/flutter_ijkplayer.dart';


void main() => runApp(new MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final title = 'LED广告屏';
    return new MaterialApp(
      title: title,
      home: new MyHomePage(
        title: title,
        channel: new IOWebSocketChannel.connect('ws://148.70.15.188:8083/websocket'),
      ),
    );
  }
}

class MyHomePage extends StatefulWidget {
  final String title;
  final WebSocketChannel channel;

  MyHomePage({Key key, @required this.title, @required this.channel})
      : super(key: key);
  @override
  _MyHomePageState createState() => new _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {

  GlobalKey rootWidgetKey = GlobalKey();
  IjkMediaController _ijkPlayerController = IjkMediaController();
  Stream<VideoInfo> videoInfoStream;
  List<Widget> imageList = List();
  List<String> videos;
  int index;

 //截图方法
  _capturePng() async {
    try {
      RenderRepaintBoundary boundary =
          rootWidgetKey.currentContext.findRenderObject();
      var image = await boundary.toImage(pixelRatio: 3.0);
      ByteData byteData = await image.toByteData(format: ImageByteFormat.png);
      Uint8List pngBytes = byteData.buffer.asUint8List();
      setState(() {});
      return pngBytes;
    } catch (e) {
      print(e);
    }
    return null;
  }

  //图片初始化接口读取
  startpic() async{
    Dio dio = new Dio();
    Response response = await dio.get('http://148.70.15.188:8787/getpiclist');
    String link1 = response.data['1'];
    String link2 = response.data['2'];
    
    link1 = 'http://148.70.15.188:8011/' + link1;
    link2 = 'http://148.70.15.188:8011/' + link2;
    
    print(link1+'\n');
    print(link2+'\n');
    
    imageList
    ..add(Image.network(
      link1,
      fit: BoxFit.fill,
    ))
    ..add(Image.network(
      link2,
      fit: BoxFit.fill,
    ));
    setState(() {
    });
  }

  //视频初始化接口读取
  startvideo() async{
    Dio dio = new Dio();
    Response response = await dio.get("http://148.70.15.188:8787/getplaylist");
    videos = response.data.toString().split(";");
    print(videos.length);
    await _ijkPlayerController.setNetworkDataSource("http://148.70.15.188:8011/"+videos[0] , autoPlay:true);
    index = 0;
  }
  List<String> links = null;

  //接收指令部分Websocket
  void websocketlisten() async{
    
    widget.channel.stream.listen((data){

      print(data);
      
      if(data.toString().contains("mp4")){
        print('收到视频链接！');
        videos = data.toString().split(";");
        print('开始播放视频！');
        print(videos.length);
        index = 0;
      }
      else if(data.toString().contains("png")){

        print('收到图片链接！');
        links = data.toString().split(';');
        imageList.clear();

        for(int i = 0 ; i < links.length ; i++)
        {
          String s = links[i];
          print("http://148.70.15.188:8011/"+s);
          imageList.add(Image.network('http://148.70.15.188:8011/'+s , fit: BoxFit.fill));
        }

        for(int i = 0 ; i < links.length ; i++)
            print(links[i]+'\n');

        print('开始图片轮播！'+links.length.toString());
        setState(() {
        });

        print("图片轮播赋值结束！");
        links = null;
      }
      else if(data.toString().contains("getscreen_pic"))
      {
        print("图片截图指令！");
        _sendFile1();
      }
      else if(data.toString().contains("getscreen_video"))
      {
        print("视频截图指令！");
        _sendFile2();
      }
    });
  }

 @override
  void initState() {
    super.initState();
    videoInfoStream = _ijkPlayerController.videoInfoStream;
    startvideo();

    //视频播放状态监控
    videoInfoStream.listen((datax){
      if(datax.progress > 0.98)
        {
          if(videos.length != 1)
          {
            index = (index+1) % videos.length;
            _ijkPlayerController.setNetworkDataSource("http://148.70.15.188:8011/"+videos[index] , autoPlay:true);
          }
          else{
            _ijkPlayerController.setNetworkDataSource("http://148.70.15.188:8011/"+videos[0] , autoPlay:true);
            index = 0;
          }
          
          // print("现在播放的是："+videos[index]);
          // print("播放列表："+videos.toString());
          // print("播放进度："+datax.progress.toString());
        }
      });

    startpic();
    websocketlisten();
  }

  @override
  Widget build(BuildContext context) {
    return RepaintBoundary(
      key: rootWidgetKey,
    child:Scaffold(
      appBar: new AppBar(
        title: new Text(widget.title),
      ),
      body: new Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            buildIjkPlayer(),
            new SizedBox(
              width: 400,
              height: 300,
              child : firstSwiperView(imageList.length),
            ),
            //屏幕长的手机可以把下面这段加上填充空白，比如 Honor 10
            // Row(children: <Widget>[
            //   new Align(
            //     alignment: Alignment.center,
            //     child: new Image.network('https://gss0.bdstatic.com/94o3dSag_xI4khGkpoWK1HF6hhy/baike'+
            //     '/c0%3Dbaike80%2C5%2C5%2C80%2C26/sign=fa9140accd95d143ce7bec711299e967/2934349b033b5bb5'+
            //     '71dc8c5133d3d539b600bc12.jpg',width: 170)
            //     ),
            //     new Container(
            //       decoration: BoxDecoration(
            //         image:DecorationImage(
            //           image:AssetImage("images/back.jpg"),
            //           fit: BoxFit.cover
            //         )
            //       ),
            //     alignment: Alignment.centerRight,
            //     child: Text('    LED RENT\n'+
            //     ' TEL:  12345678910\n'+
            //     ' Contact:  Mr.J',
            //     style: TextStyle(fontSize: 33,fontFamily: "Italianno",height: 1.35))), 
            // ]
            // )

          ],
        ),
    )
    );
  }

  // void _sendMessage(String str) {
  //    widget.channel.sink.add(str);
  // }

  //发送全屏截图
  void _sendFile1()async{
    Uint8List img = await _capturePng();
    widget.channel.sink.add(img);
  }

  //发送视频截图
  void _sendFile2()async{
    Uint8List img =  await _ijkPlayerController.screenShot();
    print(img);
    if(img != null)
      widget.channel.sink.add(img);
    else
      widget.channel.sink.add("视频播放已停止！");
  }

  //ijkplayer视频播放器
  Widget buildIjkPlayer() {
    return Container(
      child: IjkPlayer(
        mediaController: _ijkPlayerController,
      ),
    );
  }

  //swiper图片轮播
  Widget firstSwiperView(int num) {
    return Container(
      width: MediaQuery.of(context).size.width - 200,
      height: MediaQuery.of(context).size.height,
      child: Swiper(
        itemCount: num,
        key: ValueKey(num),
        itemBuilder: _swiperBuilder,
        pagination: SwiperPagination(
            alignment: Alignment.bottomCenter,
            builder: DotSwiperPaginationBuilder(
                color: Colors.black54,
                activeColor: Colors.white
            )
        ),
        controller: SwiperController(),
        scrollDirection: Axis.horizontal,
        autoplay: true,
        autoplayDisableOnInteraction: false,
        onTap: (index) => print('点击了第$index'),
        loop: true,
        index: 0,
      ),
    );
    
  }
  
  Widget _swiperBuilder(BuildContext context, int index) {
      return (imageList[index]);
    }
  
  // void disposed() {
  //   _ijkPlayerController.dispose();
  //   super.dispose();
  // }

  @override
  void dispose() {
    widget.channel.sink.close();
    super.dispose();
    _ijkPlayerController.dispose();
    super.dispose();
  }
}