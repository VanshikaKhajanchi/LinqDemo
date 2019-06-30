using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 45, 1, 22, 12, 14, 78, 90, 87, 85 };
            var b = from b1 in arr
                    where b1%2==0
                    orderby b1 descending
                    select b1;

            //foreach (var item in b)
            //{
            //    //Console.WriteLine(item);
            //}

            Student[] students = new Student[3];


            Student s1 = new Student();
            s1.Rollno = 1;
            s1.Name = "A";
            s1.SubjectName = "SA";
            s1.Age = 15;
            s1.city = "Mumbai";
            students[0] = s1;


            //property way of doing 
            Student s2 = new Student {city="Pune",Rollno=2,Name="B",SubjectName="BB",Age=21 };
            students[1] = s2;


            Student s3 = new Student();
            s3.Rollno = 3;
            s3.Name = "C";
            s3.SubjectName = "CC";
            s3.Age = 15;
            s3.city = "Mumbai";
            students[2] = s3;

            var result = from s in students
                         where s.Rollno == 2
                         select s;
            //foreach (var item in result)
            //{
            //    Console.WriteLine("----------------------------");
            //   Console.WriteLine(item.Rollno);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.SubjectName);
            //}


            var data = from sdata in students
                       where sdata.Age >= 20
                       orderby sdata.Rollno, sdata.Name
                       select sdata;

            //foreach (var item in data)
            //{
            //    Console.WriteLine("----------------------------");
            //    Console.WriteLine(item.Rollno);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.SubjectName);
            //    Console.WriteLine(item.Age);

            //}

            var p = from t in students
                    group t by t.city into cityGroup
                    select new
                    { c =cityGroup.Key,//key takes a distinct value
                        //and stored in c  ...created automatically during grpby
                        count =cityGroup.Count(),
                    allstudents=cityGroup};//citygrp ka value allstudents me h
            foreach (var item in p)
            {
                Console.WriteLine("Item Count ="+item.count+"for"+item.c);
                
                foreach (var item1 in item.allstudents)
                {
                    Console.WriteLine(item1.Rollno);
                    Console.WriteLine(item1.Name);
                    Console.WriteLine(item1.SubjectName);
                    Console.WriteLine(item1.Age);
                    Console.WriteLine(item1.city);
                    Console.WriteLine("----------------------------");
                }

            }



            Console.Read();
        }
    }
}
