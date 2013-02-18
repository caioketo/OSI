using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;

namespace OSI.Models
{
    [ActiveRecord(Schema = "public")]
    public class BaseModel : ActiveRecordBase<BaseModel>
    {
        [PrimaryKey(Generator = PrimaryKeyType.Increment)]
        public int Id { get; set; }

        [Property]
        public DateTime? ModificationDate { get; set; }

        [Property]
        public DateTime? InsertedDate { get; set; }

        [Property]
        public DateTime? DeletedDate { get; set; }
    }
}