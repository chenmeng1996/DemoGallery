cmake_minimum_required(VERSION 3.17)

# set the project name
project(cppdemo)
# set the c++ standard
set(CMAKE_CXX_STANDARD 11)

set(SOURCES
        base/base.cpp
)
add_library(common ${SOURCES})

add_executable(main main.cpp)
target_include_directories(main PRIVATE ${PROJECT_SOURCE_DIR})
target_link_libraries(main common)