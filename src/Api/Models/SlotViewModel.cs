using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class SlotViewModel
    {
        [Required]
        public string Start { get; set; }

        [Required]
        public string End { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.GetType() != obj.GetType()) return false;
            var vo = (SlotViewModel) obj;
            return this.Start.Equals(vo.Start) && this.End.Equals(vo.End);
        }

        public override int GetHashCode()
        {
            return this.Start.GetHashCode() ^ this.End.GetHashCode();
        }

        public override string ToString()
        {
            return $"Slot : {this.Start:G} - {this.End:G}";
        }
    }
}