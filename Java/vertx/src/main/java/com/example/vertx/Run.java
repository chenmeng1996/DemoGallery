package com.example.vertx;

import io.vertx.core.Vertx;

/**
 * @author Chen Meng
 *
 * 参考文章：
 * https://vertxchina.github.io/vertx-translation-chinese/start/FAQ.html
 */
public class Run {
  public static void main(String[] args) {
    Vertx vertx = Vertx.vertx();
    vertx.deployVerticle(Verticle2.class.getName());
    vertx.deployVerticle(Verticle1.class.getName());
  }
}
