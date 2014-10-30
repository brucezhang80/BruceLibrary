using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruceLibrary.Tools
{
    public class StringHelper
    {
        #region Fields
        
        #endregion

        #region Init
        public static StringHelper Current = new StringHelper();

        private StringHelper()
        {
        }
        #endregion

        #region Public



        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <param name="data">要验证的对象</param>
        public bool IsNullOrEmpty(object data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }
        #endregion
    }
}
