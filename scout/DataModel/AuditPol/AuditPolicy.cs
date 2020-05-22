using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scout.DataModel.AuditPol
{
    class AuditPolicy
    {
        public List<Category> Categories { get; private set; }

        public AuditPolicy()
        {
            Categories = new List<Category>();
        }

        public void AddCategory(Guid pvGuid, string pvDisplayName)
        {
            Categories.Add(new Category(pvGuid, pvDisplayName));
        }
    }

    abstract class CategoryBase
    {
        [JsonProperty(Order = 1)]
        public Guid Identifier { get; protected set; }

        [JsonProperty(Order = 2)]
        public string DisplayName { get; protected set; }

        protected CategoryBase()
        {
            Identifier = Guid.Empty;
            DisplayName = String.Empty;
        }
    }

    class Category : CategoryBase
    {

        [JsonProperty(Order = 3)]
        public List<SubCategory> SubCategories { get; private set; }

        private Category() : base()
        {
            SubCategories = new List<SubCategory>();
        }

        public Category(Guid pvId, string pvDisplayName) : this()
        {
            this.Identifier = pvId;
            DisplayName = pvDisplayName;
        }

        public void AddSubCategory(Guid pvGuid, string pvDisplayName, AUDIT_POLICY_INFORMATION pvAuditInfo)
        {
            SubCategories.Add(new SubCategory(pvGuid, pvDisplayName, pvAuditInfo));
        }
    }

    class SubCategory : CategoryBase
    {
        [JsonProperty(Order = 3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public AUDIT_POLICY_INFORMATION_TYPE Policy { get; private set; }

        private SubCategory() : base()
        {
            ;
        }

        public SubCategory(Guid pvGuid, string pvDisplayName, AUDIT_POLICY_INFORMATION pvAuditInfo) : this()
        {
            this.Identifier = pvGuid;
            this.DisplayName = pvDisplayName;
            this.Policy = pvAuditInfo.AuditingInformation;
        }

    }

}
