using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.DTOModels
{
    public class ForumDTO
    {
            /// <summary>看板編號</summary>
            public int Id { get; set; }
            /// <summary>看板名稱</summary>
            public string Name { get; set; }
            /// <summary>看板名稱</summary>
            public string Banner { get; set; }
            /// <summary>看板的成員數</summary>
            public int MyForums { get; set; }
            /// <summary>看板的文章數</summary>
            public int Articles { get; set; }
    }
}
