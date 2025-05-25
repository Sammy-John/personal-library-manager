using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using PersonalLibraryApp.Models;

namespace PersonalLibraryApp.Views.Components
{
    public partial class BookTableView : UserControl
    {
        public ObservableCollection<Book> Books { get; set; } = new();
        private ICollectionView? _bookView;

        public event Action<Book>? ViewBookRequested;
        public event Action<Book>? EditBookRequested;
        public event Action<Book>? DeleteBookRequested;

        private string? _currentSortProperty;
        private ListSortDirection? _currentSortDirection;

        public BookTableView()
        {
            InitializeComponent();
            Loaded += BookTableView_Loaded;
            BookListView.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(GridViewColumnHeader_Click));
        }

        private void BookTableView_Loaded(object sender, RoutedEventArgs e)
        {
            _bookView = CollectionViewSource.GetDefaultView(Books);
            BookListView.ItemsSource = _bookView;
            PopulateFilters();
            UpdateColumnHeaders();
        }

        private void PopulateFilters()
        {
            var genres = Books.Select(b => b.Genre).Distinct().OrderBy(g => g).ToList();
            GenreFilter.ItemsSource = genres;
            StatusFilter.ItemsSource = Enum.GetValues(typeof(ReadingStatus));
        }

        private void GenreFilter_SelectionChanged(object sender, SelectionChangedEventArgs e) => ApplyFilters();
        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e) => ApplyFilters();
        private void RatingFilter_SelectionChanged(object sender, SelectionChangedEventArgs e) => ApplyFilters();

        private void ApplyFilters()
        {
            if (_bookView == null) return;

            _bookView.Filter = b =>
            {
                var book = b as Book;
                if (book == null) return false;

                var genre = GenreFilter.SelectedItem as string;
                var status = StatusFilter.SelectedItem as ReadingStatus?;
                var ratingText = (RatingFilter.SelectedItem as ComboBoxItem)?.Content?.ToString();

                bool hasRatingFilter = int.TryParse(ratingText, out int ratingThreshold);

                bool genreMatch = string.IsNullOrEmpty(genre) || book.Genre == genre;
                bool statusMatch = !status.HasValue || book.Status == status;
                bool ratingMatch = true;
                if (hasRatingFilter)
                {
                    ratingMatch = book.Rating.HasValue && book.Rating.Value == ratingThreshold;
                }

                return genreMatch && statusMatch && ratingMatch;
            };

            _bookView.Refresh();
        }

        private void ClearFilters_Click(object sender, RoutedEventArgs e)
        {
            GenreFilter.SelectedItem = null;
            StatusFilter.SelectedItem = null;
            RatingFilter.SelectedItem = null;
            ApplyFilters();
        }

        private void ClearSorting_Click(object sender, RoutedEventArgs e)
        {
            _currentSortProperty = null;
            _currentSortDirection = null;
            _bookView?.SortDescriptions.Clear();
            _bookView?.Refresh();
            UpdateColumnHeaders();
        }

        private void ViewBook_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.Tag is Book book)
                ViewBookRequested?.Invoke(book);
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.Tag is Book book)
                EditBookRequested?.Invoke(book);
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.Tag is Book book)
                DeleteBookRequested?.Invoke(book);
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is not GridViewColumnHeader header || header.Column == null)
                return;

            string? sortProperty = header.Column switch
            {
                var c when c == TitleColumn => "Title",
                var c when c == AuthorColumn => "Author",
                var c when c == RatingColumn => "Rating",
                var c when c == LastReadColumn => "LastReadDate",
                _ => null
            };

            if (sortProperty == null) return;

            if (_currentSortProperty == sortProperty)
            {
                _currentSortDirection = _currentSortDirection == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
            }
            else
            {
                _currentSortProperty = sortProperty;
                _currentSortDirection = ListSortDirection.Ascending;
            }

            _bookView?.SortDescriptions.Clear();
            if (_currentSortDirection.HasValue)
            {
                _bookView?.SortDescriptions.Add(new SortDescription(_currentSortProperty, _currentSortDirection.Value));
            }

            _bookView?.Refresh();
            UpdateColumnHeaders();
        }

        private void UpdateColumnHeaders()
        {
            TitleColumn.Header = FormatHeader("Title", "Title");
            AuthorColumn.Header = FormatHeader("Author", "Author");
            RatingColumn.Header = FormatHeader("Rating", "Rating");
            LastReadColumn.Header = FormatHeader("LastReadDate", "Last Read");
        }

        private string FormatHeader(string key, string label)
        {
            if (_currentSortProperty != key)
                return label + " ⟳";
            return label + (_currentSortDirection == ListSortDirection.Ascending ? " ↑" : " ↓");
        }
    }
}
