namespace ArrayTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestNewArray()
    {
        // 一维数组
        int[] a1 = new int[10];
        // 二维数组
        int[,] a2 = new int[10, 5];
        // 三维数组
        int[,,] a3 = new int[10, 5, 2];

        // 交错数组：包含数组的数组。数组长度可以不一样
        int[][] a = new int[3][];
        a[0] = new int[10];
        a[1] = new int[5];
        a[2] = new int[20];

        // 创建一维数组的同时设置初始值
        int[] b = new int[]{1, 2, 3};
        // 简化
        int[] b1 = {1, 2, 3};


        // 遍历数组
        foreach (int item in b)
        {
            Console.WriteLine(item);
        }
    }
}