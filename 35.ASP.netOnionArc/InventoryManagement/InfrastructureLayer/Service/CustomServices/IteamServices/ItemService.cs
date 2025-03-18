using Domain.Models;
using Domain.ViewModels;
using Infrastructure.Services.CustomServices.ItemServices;
using InfrastructureLayer.Repository;
using InfrastructureLayer.Service.CustomServices.CategoryServices;
using InfrastructureLayer.Service.CustomServices.CustomerServices;
using InfrastructureLayer.Service.CustomServices.SupplierServices;
using InfrastructureLayer.Service.CustomServices.UserTypeServices;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfrastructureLayer.Service.CustomServices.ItemServices
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _item;
        private readonly IRepository<User> _user;
        private readonly IUserTypeService _userType;
        private readonly ISupplierService _supplier;
        private readonly ICustomerService _customer;
        private readonly IRepository<ItemImage> _itemImages;
        private readonly ICategoryService _category;
        private readonly IRepository<SupplierItem> _supplierItem;
        private readonly IRepository<CustomerItem> _customerItem;

        public ItemService(
            IRepository<Item> item,
            IRepository<User> user,
            IUserTypeService userType,
            ISupplierService supplier,
            ICustomerService customer,
            IRepository<ItemImage> itemImages,
            ICategoryService category,
            IRepository<SupplierItem> supplierItem,
            IRepository<CustomerItem> customerItem)
        {
            _item = item;
            _user = user;
            _userType = userType;
            _supplierItem = supplierItem;
            _category = category;
            _supplier = supplier;
            _customer = customer;
            _itemImages = itemImages;
            _customerItem = customerItem;
        }

        public async Task<ItemViewModel> Get(Guid Id)
        {
            ItemViewModel itemViewModels = new();

            SupplierItem supplierItemResult = await _supplierItem.Find(x => x.ItemId == Id);

            if (supplierItemResult != null)
            {
                Item item = await _item.Find(x => x.Id == supplierItemResult.ItemId);

                if (item == null)
                {
                    return null;
                }

                ItemViewModel itemView = new()
                {
                    ItemId = supplierItemResult.Id,
                    ItemCode = item.ItemCode,
                    ItemName = item.ItemName,
                    ItemDescription = item.ItemDescription ?? string.Empty,
                    ItemPrice = item.ItemPrice
                };
                    
                Category category = await _category.Find(x => x.Id == item.CategoryId);

                CategoryViewModel categoryView = new()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                };

                if (category != null)
                {
                    itemView.Category.Add(categoryView);
                }

                User supplier = await _supplier.Find(x => x.Id == supplierItemResult.SupplierId);
                if (supplier != null)
                {
                    UserView supplierView = new()
                    {
                        Id = supplier.Id,
                        UserName = supplier.UserName,
                        UserPhoneNo = supplier.UserPhoneNo,
                        UserEmail = supplier.UserEmail,
                        UserAddress = supplier.UserAddress,
                        UserId = supplier.UserId,
                        UserPhoto = supplier.UserPhoto
                    };

                    itemView.User.Add(supplierView);
                }

                ICollection<ItemImage> images = await _itemImages.FindAll(x => x.ItemId == supplierItemResult.ItemId);

                foreach (var img in images)
                {
                    ItemImagesView imgView = new()
                    {
                        Id = img.Id,
                        ItemId = img.ItemId,
                        ItemImage = img.ImageUrl,
                        IsActive = img.IsActive
                    };

                    itemView.ItemImages.Add(imgView);
                }

                return itemView;
            }
            else
            {
                CustomerItem customerItemResult = await _customerItem.Find(x => x.ItemId == Id);

                if (customerItemResult == null)
                {
                    return null;
                }

                Item item = await _item.Find(x => x.Id == customerItemResult.ItemId);

                if (item == null)
                {
                    return null;
                }


                ItemViewModel itemView = new()
                {
                    ItemId = item.Id,
                    ItemCode = item.ItemCode,
                    ItemName = item.ItemName,
                    ItemDescription = item.ItemDescription ?? string.Empty,
                    ItemPrice = item.ItemPrice
                };

                Category category = await _category.Find(x => x.Id == item.CategoryId);
                CategoryViewModel categoryView = new()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                };

                if (category != null)
                {
                    itemView.Category.Add(categoryView);
                }

                User customer = await _customer.Find(x => x.Id == customerItemResult.UserId);
                if (customer != null)
                {
                    UserView customerView = new()
                    {
                        Id = customer.Id,
                        UserName = customer.UserName,
                        UserPhoneNo = customer.UserPhoneNo,
                        UserEmail = customer.UserEmail,
                        UserPhoto = customer.UserPhoto
                    };

                    itemView.User.Add(customerView);
                }

                ICollection<ItemImage> images = await _itemImages.FindAll(x => x.ItemId == customerItemResult.ItemId);
                foreach (var img in images)
                {
                    ItemImagesView imgView = new()
                    {
                        Id = img.Id,
                        ItemId = img.ItemId,
                        ItemImage = img.ImageUrl,
                        IsActive = img.IsActive
                    };

                    itemView.ItemImages.Add(imgView);
                }

                return itemView;
            }
        }

        public async Task<ICollection<ItemViewModel>> GetAllItemByUser(Guid id)
        {
            ICollection<ItemViewModel> itemViewModels = new List<ItemViewModel>();

            User supplier = await _supplier.Find(x => x.Id == id);
            User customer = await _customer.Find(x => x.Id == id);

            if (supplier == null && customer == null)
            {
                return itemViewModels;
            }

            UserType userType = await _userType.Find(x => (supplier != null && x.Id == supplier.UserTypeId) || (customer != null && x.Id == customer.UserTypeId));

            if (userType == null)
            {
                return itemViewModels;
            }

            if (userType.TypeName == "Supplier")
            {
                ICollection<SupplierItem> supplierItems = await _supplierItem.FindAll(x => x.SupplierId == id);

                foreach (SupplierItem item in supplierItems)
                {
                    Item itemDetails = await _item.Find(x => x.Id == item.ItemId);
                    if (itemDetails == null) continue;

                    ItemViewModel itemView = new()
                    {
                        ItemId = itemDetails.Id,
                        ItemCode = itemDetails.ItemCode,
                        ItemName = itemDetails.ItemName,
                        ItemDescription = itemDetails.ItemDescription ?? string.Empty,  
                        ItemPrice = itemDetails.ItemPrice
                    };

                    Category category = await _category.Find(x => x.Id == itemDetails.CategoryId);
                    if (category != null)
                    {
                        itemView.Category.Add(new CategoryViewModel
                        {
                            Id = category.Id,
                            CategoryName = category.CategoryName
                        });
                    }

                    User user = await _supplier.Find(x => x.Id == item.SupplierId);
                    if (user != null)
                    {
                        itemView.User.Add(new UserView
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            UserPhoneNo = user.UserPhoneNo,
                            UserEmail = user.UserEmail,
                            UserAddress = user.UserAddress,
                            UserId = user.UserId,
                            UserPhoto = user.UserPhoto
                        });
                    }

                    ICollection<ItemImage> images = await _itemImages.FindAll(x => x.ItemId == item.ItemId);
                    foreach (var img in images)
                    {
                        itemView.ItemImages.Add(new ItemImagesView
                        {
                            Id = img.Id,
                            ItemId = img.ItemId,
                            ItemImage = img.ImageUrl,
                            IsActive = img.IsActive
                        });
                    }

                    itemViewModels.Add(itemView);
                }
            }
            else
            {
                ICollection<CustomerItem> customerItems = await _customerItem.FindAll(x => x.UserId == id);

                foreach (CustomerItem item in customerItems)
                {
                    Item itemDetails = await _item.Find(x => x.Id == item.ItemId);
                    if (itemDetails == null) continue;

                    ItemViewModel itemView = new()
                    {
                        ItemId = itemDetails.Id,
                        ItemCode = itemDetails.ItemCode,
                        ItemName = itemDetails.ItemName,
                        ItemDescription = itemDetails.ItemDescription ?? string.Empty,
                        ItemPrice = itemDetails.ItemPrice
                    };

                    Category category = await _category.Find(x => x.Id == itemDetails.CategoryId);
                    if (category != null)
                    {
                        itemView.Category.Add(new CategoryViewModel
                        {
                            Id = category.Id,
                            CategoryName = category.CategoryName
                        });
                    }

                    User user = await _customer.Find(x => x.Id == item.UserId);
                    if (user != null)
                    {
                        itemView.User.Add(new UserView
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            UserPhoneNo = user.UserPhoneNo,
                            UserEmail = user.UserEmail,
                            UserAddress = user.UserAddress,
                            UserId = user.UserId,
                            UserPhoto = user.UserPhoto
                        });
                    }

                    ICollection<ItemImage> images = await _itemImages.FindAll(x => x.ItemId == item.ItemId);
                    foreach (var img in images)
                    {
                        itemView.ItemImages.Add(new ItemImagesView
                        {
                            Id = img.Id,
                            ItemId = img.ItemId,
                            ItemImage = img.ImageUrl,
                            IsActive = img.IsActive
                        });
                    }

                    itemViewModels.Add(itemView);
                }
            }

            return itemViewModels;
        }

        public Item GetLast()
        {
            return _item.GetLast();
        }

        public async Task<bool> Insert(ItemInsertModel itemInsertModel, string image)
        {
            var user = await _user.Find(x => x.Id == itemInsertModel.UserId);
            var userType = await _userType.Find(x => x.Id == user.UserTypeId);

            var newItem = new Item
            {
                ItemCode = itemInsertModel.ItemCode,
                ItemName = itemInsertModel.ItemName,
                ItemDescription = itemInsertModel.ItemDescription,
                ItemPrice = itemInsertModel.ItemPrice,
                CategoryId = itemInsertModel.CategoryId,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                IsActive = itemInsertModel.IsActive
            };

            if (!await _item.Insert(newItem))
                return false;

            var itemImage = new ItemImage
            {
                ImageUrl = image,
                ItemId = newItem.Id,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                IsActive = true
            };

            if (!await _itemImages.Insert(itemImage))
                return false;

            if (userType.TypeName == "Supplier")
            {
                await _supplierItem.Insert(new SupplierItem
                {
                    ItemId = newItem.Id,
                    SupplierId = itemInsertModel.UserId,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    IsActive = itemInsertModel.IsActive
                });
            }
            else
            {
                await _customerItem.Insert(new CustomerItem
                {
                    ItemId = newItem.Id,
                    UserId = itemInsertModel.UserId,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    IsActive = itemInsertModel.IsActive
                });
            }

            return true;
        }



        public async Task<bool> Update(ItemUpdateModel itemUpdateModel, string image)
            {
                Item item = await _item.Get(itemUpdateModel.Id);

                item.ItemCode = itemUpdateModel.ItemCode;
                item.ItemName = itemUpdateModel.ItemName;
                item.ItemDescription = itemUpdateModel.ItemDescription;
                item.ItemPrice = itemUpdateModel.ItemPrice;
                item.CreatedOn = item.CreatedOn;
                item.UpdatedOn = DateTime.Now;
                item.IsActive = itemUpdateModel.IsActive;

                ItemImage itemImage = await _itemImages.Find(x => x.ItemId == itemUpdateModel.Id);

                itemImage.ItemId = item.Id;
                itemImage.CreatedOn = DateTime.Now;
                itemImage.UpdatedOn = DateTime.Now;
                itemImage.IsActive = itemUpdateModel.IsActive;

                if (image == null)
                    itemImage.ImageUrl = itemImage.ImageUrl;
                else
                    itemImage.ImageUrl = image;
          
                var result = await _item.Update(item);

                if (result == true)
                {
                    var resultItemImage = await _itemImages.Update(itemImage);
                    if (resultItemImage == true)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }

        public async Task<bool> Delete(Guid Id)
        {
            Item item = await _item.Get(Id);

            if (item != null)
            {
                SupplierItem supplier = await _supplierItem.Find(x => x.ItemId == item.Id);
                ItemImage itemImages = await _itemImages.Find(x => x.ItemId == item.Id);
                if (supplier != null)
                {
                    var resultSupplier = await _supplierItem.Delete(supplier);
                    if (resultSupplier == true)
                    {
                        var result = await DeleteItemAndItemImages(itemImages, item);
                        return result;
                    }   
                    else
                    {
                        var result = await DeleteItemAndItemImages(itemImages, item);
                        return result;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> DeleteItemAndItemImages(ItemImage itemImage, Item item)
        {
            if (itemImage != null)
            {
                await _itemImages.Delete(itemImage);
            }

            return await _item.Delete(item);
        }

        public Task<Item> Find(Expression<Func<Item, bool>> match)
        {
            return _item.Find(match);
        }

        public async Task<ICollection<Item>> FindAll(Expression<Func<Item, bool>> match)
        {
            return await _item.FindAll(match);
        }
    }
}