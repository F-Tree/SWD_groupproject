using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public  class TreeRelationship:BaseEntity
	{
		public Guid? FirstPersonId { get; set; }	
		public Guid? SecondPersonId { get; set;}
		public string RelationshipName { get; set; }
		public  virtual Person  FirstPerson { get; set; }	
		public virtual Person SecondPerson { get; set;}
	}
}
