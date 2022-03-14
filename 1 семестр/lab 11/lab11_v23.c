#include <stdio.h>
#define check 65536

int main(){
    char s;
    int n = 0, c = 0; // n - количество чисел, c - само число, которое будет составляться из входных цифр
    int f = 1, FLAG = 0; // Инициализируем два флага, f будет отвечать за знак числа, FLAG будет принимать значение в зависимости от того, встретилась ли нам не цифра.
    do{
        s = getchar(); // Считываем символ
        int a = s - '0'; // Изменяем тип на int
        if(s == '-'){ // Если встретился минус, то меняем значение f на отрицательное значение 
            f = -1;
        }

        // Проверка, является ли символ цифрой
        else if (a >= 0 && a <= 9){
            c = c*10 + a;
        }

        // Если встретился разделитель
        else if(s == ' ' || s == ',' || s == '\n'){
            // Проверяем допускается ли это число 16-битными процессами и является ли оно положительным
            if (c*f < check && c*f > 0 && FLAG == 0){
                n++;
                printf("%d-e число: %d\n", n, c);
            }
            c = 0; f = 1; FLAG = 0; // обнуляем с, переменные f и FLAG принимают значение по умолчанию
        }

        // Если же встретился любой другой символ, то обнуляем с и FLAG принимает значение 1
        else{
            FLAG = 1;
            c = 0;
        }
    }while (s != EOF);

    // Вывод
    printf("Всего %d чисел\n", n);
    return 0;
}
