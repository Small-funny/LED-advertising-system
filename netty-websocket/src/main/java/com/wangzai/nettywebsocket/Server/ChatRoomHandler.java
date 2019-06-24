package com.wangzai.nettywebsocket.Server;

import io.netty.channel.Channel;
import io.netty.channel.ChannelHandler;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.SimpleChannelInboundHandler;
import io.netty.channel.group.ChannelGroup;
import io.netty.channel.group.DefaultChannelGroup;
import io.netty.handler.codec.http.websocketx.TextWebSocketFrame;
import io.netty.util.concurrent.GlobalEventExecutor;
import org.springframework.stereotype.Component;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.util.List;

@Component
@ChannelHandler.Sharable
public class ChatRoomHandler extends SimpleChannelInboundHandler<TextWebSocketFrame> {


    private static ChannelGroup channels = new DefaultChannelGroup(GlobalEventExecutor.INSTANCE);
    //广播
    @Override
    protected void channelRead0(ChannelHandlerContext ctx, TextWebSocketFrame msg) throws Exception {

        //获取内容
        String content = msg.text();

        String[] ss = content.split(":");
//        System.out.println(ss.length);
//        System.out.println(ss[0]);
        if(ss[0].equals("ID"))
        {
            content = ss[2];
//            System.out.println(ss[0]);
//            System.out.println(ss[1]);
//            System.out.println(ss[2]);
        }


        if(content.contains(".mp4"))
        {
            File writename = new File("C:\\inetpub\\wwwroot\\upload_files\\playlist.txt"); // 相对路径，如果没有则要建立一个新的output。txt文件
            BufferedWriter out = new BufferedWriter(new FileWriter(writename));
            out.write(content);
            out.flush(); // 把缓存区内容压入文件
            out.close(); // 最后记得关闭文件
            System.out.println(content);
        }
        if(content.contains(".png"))
        {
            File writename = new File("C:\\inetpub\\wwwroot\\upload_files\\piclist.txt"); // 相对路径，如果没有则要建立一个新的output。txt文件
            BufferedWriter out = new BufferedWriter(new FileWriter(writename));
            out.write(content);
            out.flush(); // 把缓存区内容压入文件
            out.close(); // 最后记得关闭文件
            System.out.println(content);
        }
        //获取当前的Channel
        if(ss[0].equals("ID")) {
            for (Channel channel : channels) {
                if(channel.id().toString().equals(ss[1])) {
                    channel.writeAndFlush(new TextWebSocketFrame(content));
                    break;
                }

            }
        }
        else{
            for (Channel channel : channels) {
                channel.writeAndFlush(new TextWebSocketFrame(content));
            }
        }
    }


    //进入:,提示所有人,有人进来了
    @Override
    public void handlerAdded(ChannelHandlerContext ctx) throws Exception {

//        for (Channel channel : channels) {
//            channel.writeAndFlush(new TextWebSocketFrame(ctx.channel().remoteAddress() + "已经进入聊天室"));
//        }
        channels.add(ctx.channel());
        File writename = new File("C:\\inetpub\\wwwroot\\upload_files\\idlist.txt");
        BufferedWriter out = new BufferedWriter(new FileWriter(writename));
        for (Channel channelx : channels)
            out.write(channelx.id().toString()+";");
        out.flush(); // 把缓存区内容压入文件
        out.close(); // 最后记得关闭文件
    }

    //离开,提示
    @Override
    public void handlerRemoved(ChannelHandlerContext ctx) throws Exception {
        channels.remove(ctx.channel());
//        for (Channel channel : channels) {
//            channel.writeAndFlush(new TextWebSocketFrame(ctx.channel().remoteAddress() + "离开了聊天室"));
//        }
        File writename = new File("C:\\inetpub\\wwwroot\\upload_files\\idlist.txt");
        BufferedWriter out = new BufferedWriter(new FileWriter(writename));
        for (Channel channelx : channels)
            out.write(channelx.id().toString()+";");
        out.flush(); // 把缓存区内容压入文件
        out.close(); // 最后记得关闭文件
    }
}