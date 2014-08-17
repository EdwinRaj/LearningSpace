using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CustomImplementations;
using NUnit.Framework;

namespace ImplementationTests
{
    
    [TestFixture]
    public class CustomHashTableTests
    {
        [Test]
        public void TestSimpleInsert()
        {
            var student1 = new Student {StudentId="SN001",StudentName= "Edwin"};
            var student2 = new Student { StudentId = "SN002", StudentName = "Rini" };
            
            var hashTable = new HashTableusingLinkedList<string, Student>();
            hashTable.Insert(student1.StudentId,student1);
            hashTable.Insert(student2.StudentId, student2);
            hashTable.PrintTable();
            Assert.AreEqual(2,hashTable.Count);
        }

        [Test]
        public void InsertSameKeysThrowsException()
        {
            var student1 = new Student { StudentId = "SN001", StudentName = "Edwin" };
            var student2 = new Student { StudentId = "SN001", StudentName = "Edwin" };

            var hashTable = new HashTableusingLinkedList<string, Student>();
            hashTable.Insert(student1.StudentId, student1);

            Assert.Throws<ApplicationException>(()=> hashTable.Insert(student2.StudentId, student2));
        }

        [Test]
        public void Insert1000UniqueObjects()
        {
            var hashTable = new HashTableusingLinkedList<string, Student>();
            for (int i = 1; i <= 100; i++)
            {
                var student = new Student { StudentId = "SN00"+i, StudentName = "Edwin"+i };
                hashTable.Insert(student.StudentId,student);
            }

            hashTable.PrintTable();
        }
    }
}
