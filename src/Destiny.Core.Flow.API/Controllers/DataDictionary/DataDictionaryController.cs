﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.DataDictionnary;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.IDataDictionnary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Destiny.Core.Flow.API.Controllers.DataDictionary
{
    [Description("角色管理")]
    [Authorize]
    public class DataDictionaryController : ApiControllerBase
    {
        private readonly IDataDictionnaryServices _dataDictionnaryServices  = null;
        public DataDictionaryController(IDataDictionnaryServices dataDictionnaryServices)
        {
            _dataDictionnaryServices = dataDictionnaryServices;
        }
        /// <summary>
        /// 分页获取数据字典
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("分页获取数据字典")]
        public async Task<PageList<DataDictionaryOutPageListDto>> GetPageListAsync([FromBody]PageRequest request)
        {
            return (await _dataDictionnaryServices.GetDictionnnaryPageAsync(request)).ToPageList();
        }
        /// <summary>
        /// 修改数据字典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("修改一个数据字典")]
        public async Task<AjaxResult> UpdateAsync(DataDictionnaryInputDto input)
        {
            return (await _dataDictionnaryServices.UpdateAsync(input)).ToAjaxResult();
        }
        /// <summary>
        /// 添加数据一个数据字典
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步创建菜单")]
        public async Task<AjaxResult> CreateAsync([FromBody]DataDictionnaryInputDto dto)
        {
            return (await _dataDictionnaryServices.CreateAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        /// 根据Id删除数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("异步删除数据字典")]
        [HttpDelete]
        public async Task<AjaxResult> DeleteAsyc(Guid? id)
        {
            return (await _dataDictionnaryServices.DeleteAsync(id.Value)).ToAjaxResult();
        }
    }
}
