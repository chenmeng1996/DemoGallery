//
// Created by admin on 2021/6/17.
//

#ifndef CPPDEMO_FUNCTION_OBJECT_H
#define CPPDEMO_FUNCTION_OBJECT_H

#endif //CPPDEMO_FUNCTION_OBJECT_H

template<typename T>
class Less_than {
    const T val;
public:
    Less_than(const T& v) : val(v) {}
    bool operator()(const T& x) const { // 调用运算符，让对象像函数一样
        return x < val;
    }
};