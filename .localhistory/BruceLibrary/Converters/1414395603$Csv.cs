using System;
using System.Data;
using System.IO;

namespace BruceLibrary.Converters
{
    public class Csv
    {
        #region Fields
        
        #endregion

        #region Init
        public static Csv Current = new Csv();
        private Csv()
        {
        }
        #endregion

        #region PublicMethod
        /// <summary>
        /// 导出报表为Csv
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="strFilePath">物理路径</param>
        /// <param name="tableTeader">表头</param>
        /// <param name="columName">字段标题,逗号分隔</param>
        public bool DataTable2Csv(DataTable dataTable, string strFilePath, string tableTeader, string columName)
        {
            try
            {
                string strBufferLine = "";
                StreamWriter strmWriterObj = new StreamWriter(strFilePath, false, System.Text.Encoding.UTF8);
                strmWriterObj.WriteLine(tableTeader);
                strmWriterObj.WriteLine(columName);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    strBufferLine = "";
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (j > 0)
                            strBufferLine += ",";
                        strBufferLine += dataTable.Rows[i][j].ToString();
                    }
                    strmWriterObj.WriteLine(strBufferLine);
                }
                strmWriterObj.Close();
                return true;
            }
            catch(Exception exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 将Csv读入DataTable
        /// </summary>
        /// <param name="strFilePath">csv文件路径</param>
        /// <param name="intTitleRowNumber">表示第n行是字段title,第n+1行是记录开始</param>
        /// <param name="dataTable"></param>
        public DataTable Csv2DataTable(string strFilePath, int intTitleRowNumber, DataTable dataTable)
        {
            StreamReader reader = new StreamReader(strFilePath, System.Text.Encoding.UTF8, false);
            int i = 0, m = 0;
            reader.Peek();
            while (reader.Peek() > 0)
            {
                m = m + 1;
                string str = reader.ReadLine();
                if (m >= intTitleRowNumber + 1)
                {
                    string[] split = str.Split(',');
                    System.Data.DataRow dr = dataTable.NewRow();
                    for (i = 0; i < split.Length; i++)
                    {
                        dr[i] = split[i];
                    }
                    dataTable.Rows.Add(dr);
                }
            }
            return dataTable;
        }
        #endregion

        #region PrivateMethod

        #endregion
    }
}
