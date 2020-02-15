using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ������: ����������� ����� Filter, ������� ������ ���������� ������� ������, � ������� ������� ��������, ������� ����������� ����� ������ ����.
//   * �������� � ������� ������ ��������� � ��� �������, � ������� ��� ������� � ������������ �������.
//   * ���� � ������� ����������� ������������� ��������, �� ��� ��� �������� ������ ���� �������.
//   * ����� ������ ����������� ���������� ArgumentNullException � ������, ���� � ����� �������� null.
//   * � ������� ����������� ������������ ������ ����������� �����. ������������ LINQ ���������.

public class Program
{
    public static int[] Filter(int[] source)
    {
        bool work = false;
        List<int> list = source.ToList<int>();
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[i] == list[j])
                {
                    work = true;
                    list.RemoveAt(j);
                    j--;
                }
            }
            if (work == true)
            {
                list.RemoveAt(i);
                i--;
            }
            work = false;
        }
        int[] narray = new int[list.Count];
        narray = list.ToArray();
        return narray;
    }

        // �������� ����� ������, ���� ����������

        // ----- ��������� �������� ��� �������, ������� ��������� ���� -----

        public static void Main()
    {
        Console.WriteLine("Task is done when all test cases are correct:");

        int testCaseNumber = 1;

        TestReturnedValues(testCaseNumber++, new int[] { }, new int[] { });
        TestReturnedValues(testCaseNumber++, new int[] { 0 }, new int[] { 0 });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 1 }, new int[] { 0, 1 });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 0 }, new int[] { });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 0 }, new int[] { 1 });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 0, 1 }, new int[] { });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 2, 2, 5, 4, 4, 5, 1, 8, 4, 9, 1, 3, 4, 5, 7 }, new int[] { 0, 8, 9, 3, 7 });
        TestException<ArgumentNullException>(testCaseNumber++, null);

        if (correctTestCaseAmount == testCaseNumber - 1)
        {
            Console.WriteLine("Task is done.");
        }
        else
        {
            Console.WriteLine("TASK IS NOT DONE.");
        }
        Console.ReadLine();
    }

    private static void TestReturnedValues(int testCaseNumber, int[] array, int[] expectedResult)
    {
        try
        {
            var result = Filter(array);

            if (result.SequenceEqual(expectedResult))
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            else
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }
        catch (Exception)
        {
            Console.WriteLine(correctCaseTemplate, testCaseNumber);
        }
    }

    private static void TestException<T>(int testCaseNumber, int[] array) where T : Exception
    {
        try
        {
            Filter(array);
            Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
        }
        catch (T)
        {
            Console.WriteLine(correctCaseTemplate, testCaseNumber);
            correctTestCaseAmount++;
        }
        catch (Exception)
        {
            Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
        }
    }

    private static string correctCaseTemplate = "Case #{0} is correct.";
    private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
    private static int correctTestCaseAmount = 0;
}