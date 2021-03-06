//创建作者：Wangjiaying
//创建日期：2016.12.13
//主要功能：


using System;
using System.Security.Cryptography;

namespace MC.CheatNs
{
    public class Passward : System.Attribute
    {

        private string _name;
        private string _passward;

        /// <summary>
        /// 检查密码，传入参数为明文密码
        /// </summary>
        public bool CheckPassward(string clearPassward)
        {
            if (string.IsNullOrEmpty(_passward)) return true;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] res = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(clearPassward));
            //UnityEngine.Debug.Log(_passward + "    " + BitConverter.ToString(res).Replace("-", ""));
            return _passward == BitConverter.ToString(res).Replace("-", "");
        }

        /// <summary>
        /// 该密码对应的权限名称(描述)
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// 传入密码为MD值
        /// </summary>
        /// <param name="pass"></param>
        public Passward(string pass, string name)
        {
            _passward = pass;
            _name = name;
        }
    }
}