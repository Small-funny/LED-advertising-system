import 'package:flutter/foundation.dart';
import 'package:web_socket_channel/io.dart';
import 'package:flutter/material.dart';
import 'package:web_socket_channel/web_socket_channel.dart';
import 'dart:typed_data';
import 'package:flutter/rendering.dart';
import 'dart:ui';

void main() => runApp(new MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final title = 'LED简易控制台';
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
  TextEditingController _controller = new TextEditingController();
  GlobalKey rootWidgetKey = GlobalKey();

//List<Uint8List> images = List();

_capturePng() async {
    try {
      RenderRepaintBoundary boundary =
          rootWidgetKey.currentContext.findRenderObject();
      var image = await boundary.toImage(pixelRatio: 3.0);
      ByteData byteData = await image.toByteData(format: ImageByteFormat.png);
      Uint8List pngBytes = byteData.buffer.asUint8List();
      //images.add(pngBytes);
      setState(() {});
      return pngBytes;
    } catch (e) {
      print(e);
    }
    return null;
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
            new Form(
              child: new TextFormField(
                controller: _controller,
                decoration: new InputDecoration(labelText: '在此发送指令'),
              ),
            ),
            // new StreamBuilder(
            //   stream: widget.channel.stream,
            //   builder: (context, snapshot) {
            //     return new Padding(
            //       padding: const EdgeInsets.symmetric(vertical: 24.0),
            //       child: new Text(snapshot.hasData ? '${snapshot.data}' : ''),
            //     );
            //   },
            // ),
            new MaterialButton(
              color: Colors.blue,
              textColor: Colors.white,
              child: new Text('屏幕截图'),
              onPressed: () {
               widget.channel.sink.add("getscreen_pic");
               },
            ),
            new MaterialButton(
              color: Colors.blue,
              textColor: Colors.white,
              child: new Text('视频截图'),
              onPressed: () {
               widget.channel.sink.add("getscreen_video");
               },
            )
            // Expanded(
            //   child: ListView.builder(
            //     itemBuilder: (context, index) {
            //       return Image.memory(
            //         images[index],
            //         fit: BoxFit.cover,
            //       );
            //     },
            //     itemCount: images.length,
            //     scrollDirection: Axis.horizontal,
            //   ),
            // )
          ],
        ),
      floatingActionButton: new FloatingActionButton(
        onPressed: _sendMessage,
        tooltip: 'Send message',
        child: new Icon(Icons.send),
      ), // This trailing comma makes auto-formatting nicer for build methods.
    
    )
    );
  }

  void _sendMessage() {
    if (_controller.text.isNotEmpty) {
      widget.channel.sink.add(_controller.text);
    }
  }


  // void _sendFile()async{
  //   Uint8List img = await _capturePng();
  //   widget.channel.sink.add(img);
  // }

  @override
  void dispose() {
    widget.channel.sink.close();
    super.dispose();
  }
}
