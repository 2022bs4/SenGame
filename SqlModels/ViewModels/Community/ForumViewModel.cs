using System.Collections.Generic;
using SqlModels.DTOModels.Community;
namespace SqlModels.ViewModels.Community
{
    public class ForumViewModel
    {
        public List<ForumDTO> ForumCollection { get; set; }

        //public List<ForumData> ForumCollection { get; set; }

        //public class ForumData
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Banner { get; set; }
        //    //看板總共的成員數
        //    public int totalMembers;
        //    //看板總共的文章數
        //    public int totalArticles;
        //}
    }
}
