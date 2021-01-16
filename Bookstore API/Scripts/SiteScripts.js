$(document).ready(function () {
    getBookCount()
});

function searchForBook() {
    var input = $("#searchInput").val();
    resetMessageFields()
    if (input) {
        $('#listBooks').empty()
        $.ajax({
            url: '/api/book/search?input=' + input,
            type: 'GET',
            dataType: 'json',
            success: function (books) {
                createHtmlTable(books);
            },
            error: function (request) {
                $('#errorMessage').text(request.responseText)
            }
        });
        $("#searchInput").val('')
    }
    else {
        $('#errorMessage').text('Please enter a search string.')
    }
}

function createBook() {
    resetMessageFields()
    var data = createBookObject()
    if (dataIsValid(data)) {
        $.ajax({
            type: 'POST',
            url: 'api/book/create',
            data: data,
            dataType: 'json',
            success: function (message) {
                $('#createBookMessage').text(message)
                resettInputs()
                getBookCount()
            },
            error: function (request) {
                $('#createBookMessage').text(request.responseText)
                resettInputs()
            }
        });
    }
    else {
        $('#createBookMessage').text('missing required field input')
    }
}

function getBookCount() {
    $.ajax({
        url: '/api/book/getCount',
        type: 'GET',
        dataType: 'json',
        success: function (count) {
            $('#bookCount').text(count);
        },
        error: function (request) {
            alert(request.responseText)
        }
    });
}

function createHtmlTable(books) {
    var tableBody = ''
    for (var i = 0; i < books.length; i++) {
        tableBody +=
            '<tr>' +
            '<td> ' + books[i].Author + '</td >' +
            '<td>' + books[i].Title + '</td>' +
            '<td>' + books[i].ISBN + '</td>' +
            '</tr >'
    };
    $('#listBooks').append(tableBody);
}

function createBookObject() {
    return {
        'Author': $('#author').val(),
        'Title': $('#title').val(),
        'ISBN': $('#isbn').val(),
    }
}

function dataIsValid(data) {
    if (data.Author && data.Title && data.ISBN) {
        return true
    }
    return false
}

function resettInputs() {
    $('#author').val('')
    $('#title').val('')
    $('#isbn').val('')
}

function resetMessageFields() {
    $('#errorMessage').text('')
    $('#createBookMessage').text('')
}



