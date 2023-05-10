using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class Cell
    {
        private char m_Sign;
        private int m_XPriorty;
        private int m_OPriorty;

        public Cell(char i_Sign, int i_Priority)
        {
            m_XPriorty = m_OPriorty = i_Priority;
            m_Sign = i_Sign;
        }

        public char Sign
        {
            get
            {
                return m_Sign;
            }
            set
            {
                m_Sign = value;
            }
        }

        public int XPriority
        {
            get
            {
                return m_XPriorty;
            }
            set
            {
                m_XPriorty = value;
            }
        }
        
        public int OPriority
        {
            get
            {
                return m_OPriorty;
            }
            set
            {
                m_OPriorty = value;
            }
        }

    }
}
