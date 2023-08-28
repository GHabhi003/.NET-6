using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIAssignment.Entities
{
    /// <summary>
    /// Represent an Order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier of the order
        /// </summary>
        [Key]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Represents Auto generated Order Number 
        /// </summary>
        [Required]
        [RegularExpression(@"^(?i)ORDER_\d{4}_\d+$\r\n", ErrorMessage = "The Order number should begin with 'ORDER' followed by an underscore (_) and a sequential number.")]
        public string OrderNumber { get; set; }
        
        /// <summary>
        /// Represent Customer Name
        /// </summary>
        [Required(ErrorMessage ="Customer Name field is required.")]
        [StringLength(50, ErrorMessage ="Maximun length of the customer is 50.")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Represent the date of order
        /// </summary>
        [Required(ErrorMessage ="Order Date field is required.")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Represent the total amount
        /// </summary>
        [Range(0,double.MaxValue, ErrorMessage = "The TotalAmount field must be a positive number.")]
        [Column(TypeName ="decimal")]
        public double TotalAmount { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
