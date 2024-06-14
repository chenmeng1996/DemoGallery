cmake_minimum_required(VERSION 3.7.2)
project(CmakeExample C)

set(CMAKE_C_STANDARD 11)

include_directories(cdemo
        PRIVATE
        ../CmakeExample/include
        ../CmakeExample/include-other
)

add_executable(test test.c
        hello.c
        hello.h
)