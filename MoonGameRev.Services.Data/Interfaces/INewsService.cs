﻿namespace MoonGameRev.Services.Data.Interfaces
{
    using MoonGameRev.Services.Data.Models.News;
    using MoonGameRev.Web.ViewModels.Home;
    using MoonGameRev.Web.ViewModels.News;

    public interface INewsService
    {
        Task<string> CreateAsync(NewsFormModel formModel, string journalistId);

        Task<AllNewsFilteredAndPagedServiceModel> AllAsync(AllNewsQueryModel queryModel);

        Task<IEnumerable<NewsAllViewModel>> AllByJournalistIdAsync(string journalistID);

        Task<NewsDetailsViewModel> GetDetailsByIdAsync(string newsId);

        Task<bool> ExistsByIdAsync(string newsId);

        Task<NewsFormModel> GetNewsForEditAsync(string id);

        Task<bool> IsJournalistWithIdOwnerOfTheNewsIdAsync(string newsId, string journalistID);

        Task EditNewsByIdAndFormModelAsync(string newsId, NewsFormModel model);

        Task<NewsPreDeleteDetailsViewModel> GetNewsForDeleteByIdAsync(string newsId);

        Task DeleteByIdAsync(string newsId);

        Task<IEnumerable<IndexViewModel>> LatestNewsAsync();
    }
}
