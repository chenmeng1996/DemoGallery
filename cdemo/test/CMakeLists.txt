cmake_minimum_required(VERSION 3.7.2)
project(cdemo C)

set(CMAKE_C_STANDARD 11)


add_executable(fork cmd/fork.c)
add_executable(show cmd/show.c)
add_executable(cp cmd/cp.c)
add_executable(mkstemp cmd/mkstemp.c)
add_executable(environment cmd/environment.c)

add_executable(tcp_server_server tcp_server/server.c)
add_executable(tcp_server_client tcp_server/client.c)

add_executable(io_select_client io/select/client.c)
add_executable(io_select_server io/select/server.c)
add_executable(mutex_lock_example thread/mutex_lock_example.c)
