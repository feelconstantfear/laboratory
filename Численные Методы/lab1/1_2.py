"""
Реализовать метод прогонки в виде программы, задавая в качестве
входных данных ненулевые элементы матрицы системы и вектор правых частей.
Используя разработанное программное обеспечение, решить СЛАУ
с трехдиагональной матрицей.

Вариант: 26
"""


def tridiagonal_solver(a: list[int], b: list[int], c: list[int], d: list[int]):
    """
    Функция решения СЛАУ с трехдиагональной матрицей
    с помощью метода прогонки

    Args:
        - a (list[int]): Нижняя диагональ
        - b (list[int]): Главная диагональ
        - c (list[int]): Верхняя диагональ
        - d (list[int]): Вектор правых частей

    Returns:
        - list[float]: Возвращает вектор X, решение СЛАУ
    """
    n = len(d)
    alpha = [0.0] * n
    beta = [0.0] * n
    x = [0.0] * n

    # Прямой ход
    alpha[0] = b[0]
    beta[0] = d[0] / alpha[0]

    for i in range(1, n):
        alpha[i] = b[i] - a[i] * c[i-1] / alpha[i-1]
        beta[i] = (d[i] - a[i] * beta[i-1]) / alpha[i]

    # Обратный ход
    x[-1] = beta[-1]
    for i in range(n-2, -1, -1):
        x[i] = beta[i] - c[i] * x[i+1] / alpha[i]

    return x


if __name__ == "__main__":
    #   [[-12, -7, -0, 0, 0],
    #    [-7, -11, -3, 0, 0],
    #    [0, -7, 21, -8, 0],
    #    [0, 0, 4, -13, 5],
    #    [0, 0, 0, -6, 11]]

    A = [0, -7, -7, 4, -6]   # нижняя диагональ
    B = [-12, -11, 21, -13, 11]   # главная диагональ
    C = [-7, -3, -8, 5, 0]   # верхняя диагональ
    D = [-102, -92, -64, 38, -12]  # вектор правых частей

    # Решение СЛАУ
    solution = tridiagonal_solver(A, B, C, D)
    print("Решение СЛАУ:", solution)
