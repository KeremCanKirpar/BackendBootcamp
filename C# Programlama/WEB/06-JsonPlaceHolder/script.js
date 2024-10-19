$(document).ready(function () {
    function loadPosts() {
        $.ajax({
            url: 'https://jsonplaceholder.typicode.com/posts',
            method: 'GET',
            success: function (posts) {
                let postsHtml = '';
                posts.forEach(post => {
                    postsHtml += `
                            <div class="col-3">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">${post.id}</h5>
                                        <p class="card-text">${post.title}</p>
                                        <a href="#" class="btn btn-primary">Oku</a>
                                    </div>
                                </div>
                            </div>
                    `;
                });
                $('#post').html(postsHtml);
            },
            error: function (err) {
                console.log(err)
            }

        })
    };
    loadPosts();
});