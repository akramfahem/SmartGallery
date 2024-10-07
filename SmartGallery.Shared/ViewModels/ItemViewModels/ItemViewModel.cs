using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGallery.Shared.ViewModels.ItemViewModels;

public class ItemViewModel
{
    public ItemViewModel(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public ItemViewModel()
    {

    }
    public int Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object o)
    {
        var other = o as ItemViewModel;
        return other?.Name == Name;
    }
    public override int GetHashCode() => Name?.GetHashCode() ?? 0;
    public override string ToString() => Name;
}


