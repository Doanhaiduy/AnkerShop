//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class MoTaSanPham
    {
        public int Id { get; set; }
        public string IdSP { get; set; }
        public string Anh { get; set; }
        public string MoTa { get; set; }
    
        public virtual SanPham SanPham { get; set; }
    }
}
