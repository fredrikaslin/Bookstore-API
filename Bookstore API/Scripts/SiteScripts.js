$(document).ready(function () {



});



function searchForBook() {
    var isbn = $("#searchInput").val();
    console.log("input", isbn)
        $.ajax({
            url: '/api/bookinfo/?ISBN='+isbn,
            type: 'GET',
            dataType: 'json',
            success: function (books) {
                createHtmlTable(books);
            },
            error: function (request, message, error) {
                handleException(request, message, error);
            }
        });
}

function createHtmlTable(books) {
    console.log(books)
    var table = $('#bookTable');
    table.html('');
    table.append('<thead>');
    table.append('<tr>');
    table.append('<th>Author</td>');
    table.append('<th>Title</td>');
    table.append('<th>ISBN</td>');
    table.append('</tr>');
    table.append('</thead>');
    table.append('<tbody>');
    $.each(books, function (i, item) {

        table.append('<tr>');
        table.append('<td>' + item.Author + '</td>');
        table.append('<td>' + item.Title + '</td>');
        table.append('<td>' + item.ISBN + '</td>');
        table.append('</tr>');
    });
    table.append('</tbody>');
    table.append('</table>');
}



