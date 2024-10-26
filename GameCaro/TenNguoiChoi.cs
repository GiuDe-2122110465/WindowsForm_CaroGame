using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
    internal class TenNguoiChoi
    {
        private string name;

        public string Name { get => name; set => name = value; }
        private Image mark;
        public Image Mark { get => mark; set => mark = value; }
        public TenNguoiChoi(string name, Image mark)
        {
            this.name = name;
            this.mark = mark;
        }


    }
}
