using System.Collections.Generic;

class MergeSortService
{
    public List<Student> MergeSort(List<Student> students)
    {
        if (students.Count <= 1)
            return students;

        int mid = students.Count / 2;

        List<Student> left = students.GetRange(0, mid);
        List<Student> right = students.GetRange(mid, students.Count - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private List<Student> Merge(List<Student> left, List<Student> right)
    {
        List<Student> result = new List<Student>();
        int i = 0;
        int j = 0;

        while (i < left.Count && j < right.Count)
        {
            if (left[i].Marks >= right[j].Marks)
            {
                result.Add(left[i]);
                i++;
            }
            else
            {
                result.Add(right[j]);
                j++;
            }
        }

        while (i < left.Count)
        {
            result.Add(left[i]);
            i++;
        }

        while (j < right.Count)
        {
            result.Add(right[j]);
            j++;
        }

        return result;
    }
}
