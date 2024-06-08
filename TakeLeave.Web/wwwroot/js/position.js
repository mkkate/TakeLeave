$("#position-title").on('change', function () {
    var title = $(this).val();
    if (title) {
        var url = `/HR/Positions/GetSeniorityLevelsForSpecifiedTitle?title=${title}`;
        $.get(url, function (data) {
            var seniorityLevelsDropdown = $("#seniority-level");
            seniorityLevelsDropdown.empty();
            seniorityLevelsDropdown.append('<option value="">Select level:</option>');
            $.each(data, function (index, item) {
                seniorityLevelsDropdown.append(
                    `<option value="${item}">${item}</option>`
                );
            });
        });
    }
    else {
        console.error('Error fetching seniority levels:', error);
        $('#seniority-level').append('<option value="">Select level:</option>');
    }
});