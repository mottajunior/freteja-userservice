using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Entities
{
    public class Entity
    {
        public int Id { get; private set; }
        
        public Entity(int id){
            this.Id = id;            
        }
    }
}
