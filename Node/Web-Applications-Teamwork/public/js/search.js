const search = () => {
    $('#search-btn').click(() => {
        const pattern = $('#pattern').val();
        const searchOption = $('input[name="searchOption"]:checked').val();
        $('.search-results').empty();

        if (pattern.length > 0) {
            const url = `/search/${searchOption}?name=${pattern}&isPartial=true`;

            requester.get(url)
                .then((response) => {
                    $('.search-results').html(response);
                    window.history.pushState('Search', 'Title', `/search/${searchOption}?name=${pattern}`);
                });
        }
    });
};
