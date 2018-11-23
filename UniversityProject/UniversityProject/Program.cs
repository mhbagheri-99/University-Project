using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityProject
{
    internal class DoubleNode
    {
        internal Object data;
        internal DoubleNode prev;
        internal DoubleNode next;
        public DoubleNode(Object b)
        {
            data = b;
            prev = null;
            next = null;
        }
    }

    internal class DoubleLinkedList
    {
        internal DoubleNode head;

        public DoubleLinkedList()
        {
            head = null;
        }
        public DoubleLinkedList(Object data)
        {
            head = new DoubleNode(data);
        }
        public DoubleNode GetLastNode()
        {
            DoubleNode temp = this.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        public void InsertLast(Object data)
        {
            DoubleNode newNode = new DoubleNode(data);
            if (this.head == null)
            {
                newNode.prev = null;
                this.head = newNode;
                return;
            }
            DoubleNode lastNode = this.GetLastNode();
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }
        public void InsertFront(Object data)
        {
            DoubleNode newNode = new DoubleNode(data);
            newNode.next = this.head;
            newNode.prev = null;
            if (this.head != null)
            {
                this.head.prev = newNode;
            }
            this.head = newNode;
        }
        public void DeleteNodebyKey(Object key)
        {
            DoubleNode temp = this.head;
            if (temp != null && temp.data == key)
            {
                this.head = temp.next;
                this.head.prev = null;
                return;
            }
            while (temp != null && temp.data != key)
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }

    }

    public class Student
    {
        String id;
        String name;
        String family;
        String major;
        int year;
        sbyte semester;

        //Student next;
        //static LinkedList<Units>[] units;

        public Student()
        {
            //next = null;
            //units = null;
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Family
        {
            get { return family; }
            set { family = value; }
        }
        public String Major
        {
            get { return major; }
            set { major = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public sbyte Semsester
        {
            get { return semester; }
            set { semester = value; }
        }


    }

    public class Units
    {
        public String courseName;
        public String code;
        public String testDate;
        public String date;

        public Units next;
        public Units(String courseName, String code, String testDate, String date)
        {
            this.courseName = courseName;
            this.code = code;
            this.testDate = testDate;
            this.date = date;
            next = null;

        }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Units u = new Units("DS", "123", "1", "1");
            DoubleLinkedList unitsList = new DoubleLinkedList(u);
            unitsList.InsertLast(new Units("CS", "124", "2", "2"));
            unitsList.InsertLast(new Units("SE", "125", "3", "3"));

        }
    }
}
