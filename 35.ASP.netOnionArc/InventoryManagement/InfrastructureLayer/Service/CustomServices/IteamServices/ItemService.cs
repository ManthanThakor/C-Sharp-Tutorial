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
                    Id = supplierItemResult.Id,
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
                    return null;

                Item item = await _item.Find(x => x.Id == customerItemResult.ItemId);

                if (item == null)
                    return null;

                ItemViewModel itemView = new()
                {
                    Id = item.Id,
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
            UserType userType = await _userType.Find(x => x.Id == supplier.UserTypeId || x.Id == customer.UserTypeId);

            if (userType.TypeName == "Supplier")
            {
                ICollection<SupplierItem> ans = await _supplierItem.FindAll(x => x.SupplierId == id);

                foreach (SupplierItem item in ans)
                {
                    Item iteam = await _item.Find(x => x.Id == item.ItemId);
                    ItemViewModel itemViewModel = new()
                    {
                        ItemId = item.ItemId,
                        ItemCode = item.ItemCode,
                        ItemName = item.ItemName,
                        ItemDescription = item.ItemDescription,
                        ItemPrice = item.ItemPrice
                    };

                    Category category = await _category.Find(x => x.Id == item.CategoryId);

                    CategoryViewModel categoryView = new()
                    {
                        Id = category.Id,
                        CategoryName = category.CategoryName
                    };

                    itemView.Category.Add(categoryView)



                        User user = await _supplier.Find(x => x.Id == item.UserId);
                    UserView view = new()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        UserPhoneno = user.UserPhoneno,
                        UserEmail = user.UserEmail,
                        UserAddress = user.UserAddress,
                        UserID = user.UserID,
                        UserPhoto = user.UserPhoto
                    };
                    itemView.User.Add(view);

                    ICollection<ItemImage> image = await _itemImages.FindAll(x => )
                    foreach (var img in image)

                    {
                        ItemImagesView img View = new()
                        {
                            Id = img.Id,
                            ItemId img.ItemId,
                            ItemImage = img.ItemImage,
                            IsActive = img.IsActive
                        };
                        itemView.ItemImages.Add(imgView);

                    }
                    itemViewModels.Add(itemView);
                }
                return itemViewModels;
            }
            else
                return itemViewModels
  }else{

        


            public Item GetLast()
            {
                return _item.GetLast();
            }

            public async Task<bool> Insert(ItemInsertModel itemInsertModel, string image)
            {
                var user = await _user.Find(x => x.Id == itemInsertModel.UserId);
                var UserType = await _userType.Find(x => x.Id == user.UserTypeId);

                if (UserType.TypeName == "Supplier")
                {
                    Item newItem = new()
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
                    var result = await _item.Insert(newItem);
                    if (result == true)
                    {
                        SupplierItem supplierItem = new()
                        {
                            ItemId = item.Id,
                            UserId = itemInsertModel.UserId,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now,
                            IsActive = itemInsertModel.IsActive
                        };

                        ItemImage itemImage = new()
                        {
                            ImageUrl = image,
                            ItemId = Item.,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now,
                            IsActive = true
                        };

                        var resultItemImage = await _itemImages.Insert(itemImage);
                        if (resultItemImage == true)
                        {
                            await _supplierItem.Insert(supplierItem);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }

                else
                {
                    Item newItem = new()
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
                    var result = await _item.Insert(newItem);
                    if (result == true)
                    {
                        CustomerItem customerItem = new()
                        {
                            ItemId = item.Id,
                            UserId = itemInsertModel.UserId,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now,
                            IsActive = itemInsertModel.IsActive
                        };

                        ItemImage itemImage = new()
                        {
                            ImageUrl = image,
                            ItemId = Item.id,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now,
                            IsActive = true
                        };

                        var resultItemImage = await _itemImages.Insert(itemImage);
                        if (resultItemImage == true)
                        {
                            await _supplierItem.Insert(customerItem);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
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
                    itemImage.ItemImage = itemImage.ItemImage;
                else
                    itemImage.ItemImage = image;
                var result = await _item.Update(item);
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
                Item item = await _item.Get(Id)
            ;

                if (item != null)
                {
                    SupplierItem supplier = await _supplierItem.Find(x => x.ItemId == item.Id);
                    ItemImages itemImages = await _itemImages.Find(x => x.ItemId == item.Id);
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
            }

            private async Task<bool> DeleteItemAndItemImages(ItemImages itemImages, Item item)
            {
                if (itemImages != null)
                {
                    var resultItemImages = await _itemImages.Delete(itemImages);
                    if (resultItemImages == true)
                    {
                        var resultItem = await _item.Delete(item);
                        if (resultItem == true)
                        {
                            return true;
            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                    {
                        var resultItem = await _item.Delete(item);
                        if (resultItem == true)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                }
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