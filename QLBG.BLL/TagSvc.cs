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
    public class TagSvc : GenericSvc<TagRep,Tag>
    {
        TagRep tagRep = new TagRep();

        public SingleRsp CreateTag(TagReq tagReq)
        {
            var res = new SingleRsp();
            Tag tag = new Tag();
            tag.Name = tagReq.Name;
            res = tagRep.CreateTag(tag);
            return res;
        }
    }
}
