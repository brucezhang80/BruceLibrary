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




        #region 判断对象是否为空
        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <typeparam name="T">要验证的对象的类型</typeparam>
        /// <param name="data">要验证的对象</param>        
        public bool IsNullOrEmpty<T>(T data)
        {
            if (data == null){return true;}

            if (data is string)
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            if (data is DBNull){return true;}
            return false;
        }
        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <param name="data">要验证的对象</param>
        public bool IsNullOrEmpty(object data)
        {
            if (data == null){return true;}

            if (data is string){
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            if (data is DBNull){return true;}

            return false;
        }
        #endregion

        #endregion
    }
}
