package com.nettywebsocket.Server;

import io.netty.buffer.ByteBuf;
import io.netty.buffer.Unpooled;
import io.netty.channel.ChannelHandler;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.SimpleChannelInboundHandler;
import io.netty.handler.codec.http.websocketx.BinaryWebSocketFrame;
import org.springframework.stereotype.Component;
import sun.misc.BASE64Decoder;
import sun.misc.BASE64Encoder;

import java.awt.*;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.text.SimpleDateFormat;
import java.util.Date;

@Component
@ChannelHandler.Sharable
public class FileHandler extends SimpleChannelInboundHandler<BinaryWebSocketFrame> {

    @Override
    protected void channelRead0(ChannelHandlerContext ctx, BinaryWebSocketFrame msg) throws Exception {
        ByteBuf content = msg.content();
        byte[] b = new byte[content.capacity()];
        content.readBytes(b);
        System.out.println(b);
        SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd[HH-mm-ss]");
        OutputStream os = new FileOutputStream("C:\\inetpub\\wwwroot\\upload_files\\getscreen\\"+ctx.channel().remoteAddress().toString().replace("/","").replace(":","+")+"+"+df.format(new Date())+".png");
        os.write(b , 0 , b.length);
        os.flush();
        os.close();
    }
}
