//
// Created by meng on 2024/6/14.
//

#include <pthread.h>
#include <stdio.h>

pthread_mutex_t lock;

void *thread_func(void *arg) {
    pthread_mutex_lock(&lock);
    printf("Thread %ld in critical section\n", (long)arg);
    pthread_mutex_unlock(&lock);
    return NULL;
}

int main() {
    pthread_t threads[2];
    pthread_mutex_init(&lock, NULL);

    for (long i = 0; i < 2; i++) {
        pthread_create(&threads[i], NULL, thread_func, (void *)i);
    }

    for (int i = 0; i < 2; i++) {
        pthread_join(threads[i], NULL);
    }

    pthread_mutex_destroy(&lock);
}