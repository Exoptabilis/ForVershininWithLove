//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kyrsach.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public int IdArticle { get; set; }
        public string name { get; set; }
        public string thema { get; set; }
        public string text { get; set; }
        public System.DateTime dataAdd { get; set; }
        public int idTest { get; set; }
    
        public virtual Test Test { get; set; }
    }
}
