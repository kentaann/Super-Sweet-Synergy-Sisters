#region Using Statements

using System;
using System.IO;

#endregion

namespace SuperSweetAnalyser
{
    public class TextReader
    {
        #region Variables

        private int m_counter;

        private string m_line;

        StreamReader m_fileToRead;

        #endregion

        #region Constructor
        /// <summary>
        /// Reads a file line by line
        /// </summary>
        /// <param name="path">Text file to read</param>
        public TextReader(string path)
        {
            m_counter = 0;
            m_fileToRead = new StreamReader(path);
            ReadLine();
        }

        #endregion

        #region Read Line
        /// <summary>
        /// While the line is not empty reads the file line by line and writes it.
        /// </summary>
        private void ReadLine()
        {
            while ((m_line = m_fileToRead.ReadLine()) != null)
            {
                Console.WriteLine(m_line);
                m_counter++;
            }

            m_fileToRead.Close();
            Console.ReadLine();
        }

        #endregion
    }
}