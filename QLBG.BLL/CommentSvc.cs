using QLBG.Common.BLL;
using QLBG.Common.Req;
using QLBG.Common.Rsp;
using QLBG.DAL;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.BLL
{
    public class CommentSvc : GenericSvc<CommentRep,Comment>
    {
        CommentRep commentRep = new CommentRep();
        public SingleRsp AddComment(CommentReq commentReq,int id)
        {
            
            Comment comment1 = new Comment();
            comment1.CreatedDate = DateTime.Now;
            comment1.Rate = commentReq.Rate;
            comment1.Comment1 = commentReq.Comment1;
            comment1.Id = id;

            return commentRep.AddComment(comment1);
        }
        public SingleRsp GetComment(int id)
        {
            var res = commentRep.GetComment(id);
            return res;
        }
    }
}
