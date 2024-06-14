package com.example.vertx;

import io.vertx.core.AbstractVerticle;

/**
 * @author Chen Meng
 */
public class Verticle2 extends AbstractVerticle {
  // 并发安全
  int i = 0;

  @Override
  public void start() throws Exception {

    vertx.createHttpServer().requestHandler(req -> {
      i++;
      req.response().end(""); // 要关闭请求，否则连接很快被占满
    }).listen(8082);

    vertx.createHttpServer().requestHandler(req -> {
      System.out.println(i);
      req.response().end("" + i);
    }).listen(8081);
  }
}
