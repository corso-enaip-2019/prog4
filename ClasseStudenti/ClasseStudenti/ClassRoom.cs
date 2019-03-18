using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseStudenti
{
    class Classroom
    {
        List<Students> m_students = new List<Students>();

        public int Grade { get; }

        public Classroom(int grade) { Grade = grade; }
    }
}
