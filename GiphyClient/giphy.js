//GiphyAPI (Server) host details for API calls
const HOST = 'localhost';
const PORT = '7032';
const API = 'https://' + HOST + ':' + PORT;
const METHODS = 'GET, POST, DELETE, OPTIONS';

//set for testing purposes
let loggedInUserId = 'd5a56226-b27b-4477-8795-7296c7c5db09';

//throws 405 error
function login(){
    let email = document.getElementById('email').value;
    let password = document.getElementById('password').value;
    fetch(`${API}/login`, {
        method: 'POST',
        credentials: 'include',
        headers: {
            'Access-Control-Allow-Origin': `${API}`,
            'Access-Control-Allow-Methods': `${METHODS}`,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email: `${email}`,
            password: `${password}`,
            twoFactorCode: 'string',
            twoFactorRecoveryCode: 'string'
        })
    })
        .then(response => {
            console.log(response)
        })
        // .then(response => console.log(response.json()))
        // .then(data => console.log(data))
        .catch(error => console.log(error))
}

//calls the API to delete a comment by the given commentId
function deleteGifComment(commentId){
    fetch(`${API}/comments/gif/delete/${commentId}`, {
        method: 'DELETE'
    })
        .catch(error => console.log(error))  
}

//calls the API to update a comment by the given gifId, commentId, and comment-content
function updateGifComment(gifId, commentId){
    let commentContent = document.getElementById(`comment-content-${commentId}-edit`).value;
    fetch(`${API}/comments/gif/update/${gifId}/${loggedInUserId}/${commentId}`, {
        method: 'POST',
        body: JSON.stringify({
            'Comment-Content': `${commentContent}`
        })
    })
        .catch(error => console.log(error))
    getGifComments(gifId);
}

function editGifComment(gifId, commentId){
    let currentGifCommentContent = document.getElementById(`comment-content-${commentId}`).innerHTML;
    document.getElementById(`comment-content-${commentId}`).innerHTML = `
        <div class="row">
            <div class="col-md-10 col-sm-6 col-xs-6">
                <textarea class="form-control bi bi-send-arrow-up" id="comment-content-${commentId}-edit" rows="1">${currentGifCommentContent}</textarea>
            </div>
            <div class="col-md-2 col-sm-6 col-xs-3">
                <a class="cursor-pointer" onclick="updateGifComment('${gifId}', '${commentId}')"><img src="images/Send.png" class="img-fluid"></a>
            </div>
        </div>
        `
}

//displays a gif comment and the username of the reviewer
//includes a pencil button and "X" button to update and delete a rating if the given rating was made by the currently logged in user
function listGifComments(data){
    let commentDisplay = `
        <div class="collapse show" id="show-comment-${data.id}">
            <div class="text-white fs-5" id="comment-content-${data.id}">${data.content}</div>
            <div class="text-white-50">${data.username}
        `
    if(data.userId == loggedInUserId){
        commentDisplay += `
            <button type="button" class="btn text-light" onclick="editGifComment('${data.gifId}','${data.id}')">&#9999;</button>
            <button type="button" class="btn btn-close btn-close-white" onclick="deleteGifComment('${data.id}')" data-bs-toggle="collapse" data-bs-target="#show-comment-${data.id}" aria-expanded="true" aria-controls="show-comment-${data.id}"></button>
            `
    }
    commentDisplay += `</div></div>`
    return commentDisplay
}

//calls the API to get any comments of a gif by the given gifId
function getGifComments(gifId){
    fetch(`${API}/comments/gif/${gifId}`)
        .then(response => {return response.json()})
        .then(data => {
            document.getElementById('gif-comments').innerHTML = `${data.map(listGifComments).join("")}`
        })
        .catch(error => console.log(error))
}

//calls the API to create a comment by the given gifId, userId, and comment-content
function createGifComment(gifId){
    let commentContent = document.getElementById('comment-content').value;
    document.getElementById('comment-content').value = '';
    fetch(`${API}/comments/gif/create/${gifId}/${loggedInUserId}`, {
        method: 'POST',
        body: JSON.stringify({
            'Comment-Content': `${commentContent}`
        })
    })
        .catch(error => console.log(error))
    getGifComments(gifId);
}

//calls the API to delete the rating by the given gifId and userId
function deleteGifRating(gifId){
    fetch(`${API}/ratings/gif/delete/${gifId}/${loggedInUserId}`, {
        method: 'DELETE'
    })
        .catch(error => console.log(error))     
}

//displays gif rating stars and the username of the reviewer
//includes an "X" button to delete a rating if the given rating was made by the currently logged in user
function listGifRatings(data){
    let starRating = '';
    for(let i =0; i < data.rating; i++){
        starRating += '&#9733';
    }
    let ratingDisplay = `
        <div class="collapse show" id="show-current-user-rating">
            <div class="text-white fs-3">${starRating}</div>
            <div class="text-white-50">${data.username}
        `
    if(data.userId == loggedInUserId){
        ratingDisplay += `
            <button type="button" class="btn btn-close btn-close-white" onclick="deleteGifRating('${data.gifId}')" data-bs-toggle="collapse" data-bs-target="#show-current-user-rating" aria-expanded="true" aria-controls="show-current-user-rating"></button>
            `
    }
    ratingDisplay += `</div></div>`
    return ratingDisplay
}

//calls the API to get any ratings of a gif by the given gifId
function getGifRatings(gifId){
    fetch(`${API}/ratings/gif/${gifId}`)
        .then(response => {return response.json()})
        .then(data => {
            document.getElementById('gif-ratings').innerHTML = `${data.map(listGifRatings).join("")}`
        })
        .catch(error => console.log(error))
}

//calls the API to create a rating or update a rating if it already exists by the given gifId and rating
function rateGif(gifId, rating){
    fetch(`${API}/ratings/gif/update/${gifId}/${loggedInUserId}/${rating}`, {
        method: 'POST'
    })
        .catch(error => console.log(error))
    getGifRatings(gifId);
}

//generates the gif view sidebar by the given gif data
function generateSideBar(data){
    let title = data.title;
    if(data.title == null){
        title = ''
    }
    let username = data.username;
    if(data.username == null){
        username = ''
    }
    let url = data.url;
    if(data.url == null){
        url = ''
    }
    let embed_url = data.embed_url;
    if(data.embed_url == null){
        embed_url = ''
    }
    document.getElementById('sidebar').innerHTML = `
            <div class="d-flex flex-column flex-shrink-0 p-3 text-white black-background" >
                    <br/><br/><br/>
                    <span class="fs-4">${title}</span>
                    <span class="fs-5 text-white-50">${username}</span>
                    <a href="${url}">
                        <div style="width:100%;height:0;padding-bottom:100%;position:relative;">
                            <iframe src="${embed_url}" width="100%" height="100%" style="position:absolute" frameBorder="0" class="giphy-embed" allowFullScreen></iframe>
                        </div>
                    </a>
                    <hr>
                    <div class="d-flex justify-content-center">
                        <fieldset class="star fs-2">
                            <input type="radio" id="star5" name="star" onclick="rateGif('${data.id}', 5)"/><label for="star5">&#9733</label>
                            <input type="radio" id="star4" name="star" onclick="rateGif('${data.id}', 4)"/><label for="star4">&#9733</label>
                            <input type="radio" id="star3" name="star" onclick="rateGif('${data.id}', 3)"/><label for="star3">&#9733</label>
                            <input type="radio" id="star2" name="star" onclick="rateGif('${data.id}', 2)"/><label for="star2">&#9733</label>
                            <input type="radio" id="star1" name="star" onclick="rateGif('${data.id}', 1)"/><label for="star1">&#9733</label>
                        </fieldset>
                    </div>
                    <div>
                        <div class="dropdown dropdown-toggle text-center cursor-pointer" data-bs-toggle="collapse" data-bs-target="#show-ratings" aria-expanded="false" aria-controls="show-ratings">Ratings</div>
                        <div class="collapse collapse-horizontal text-center show" id="show-ratings">
                            <span id="gif-ratings"></span>
                        </div>
                    </div>
                    <hr>
                    <div class="row">
                        <div class="col-md-10 col-sm-6 col-xs-6">
                            <textarea class="form-control bi bi-send-arrow-up" id="comment-content" rows="1" placeholder="Add a comment..."></textarea>
                        </div>
                        <div class="col-md-2 col-sm-6 col-xs-3">
                            <a class="cursor-pointer" onclick="createGifComment('${data.id}')"><img src="images/Send.png" class="img-fluid"></a>
                        </div>
                    </div>
                    <br/>
                    <div>    
                        <div class="dropdown dropdown-toggle text-center cursor-pointer" data-bs-toggle="collapse" data-bs-target="#show-comments" aria-expanded="false" aria-controls="show-comments">Comments</div>    
                        <div class="collapse collapse-horizontal text-center show" id="show-comments">
                            <span id="gif-comments"></span>
                        </div>
                    </div>
                    <hr>
                </div>
            </div>
            `;
}

//calls the API to retrieve a gif by the given gifId
function viewGifInfo(gifId){
    fetch(`${API}/giphy/gifs/${gifId}`)
        .then(response => {return response.json()})
        .then(data => {
            generateSideBar(data.data);
            getGifRatings(data.data.id);
            getGifComments(data.data.id);
        })
        .catch(error => console.log(error))
}

//generates cards of each gif by the given array of gifs
function dataCard(data){
    let title = data.title;
    if(data.title == null){
        title = ''
    }
    let username = data.username;
    if(data.username == null){
        username = ''
    }
    let url = data.url;
    if(data.url == null){
        url = ''
    }
    let embed_url = data.embed_url;
    if(data.embed_url == null){
        embed_url = ''
    }
    return `
    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-5">
        <div class="card black-background">
            <div class="card-body">
                <a href="${url}">
                    <div style="width:100%;height:0;padding-bottom:100%;position:relative;">
                        <iframe src="${embed_url}" width="100%" height="100%" style="position:absolute" frameBorder="0" class="giphy-embed" allowFullScreen></iframe>
                    </div>
                </a>
                <h6 class="card-title text-white">${title}</h6>
                <h6 class="card-subtitle mb-2 text-body text-white-50">${username}</h6>
                <div class="text-center">
                    <button type="button" class="btn btn-dark" onclick="viewGifInfo('${data.id}')">View More</button>
                </div>
            </div>
        </div>
        <br/>
    </div>
    `
}

//calls the API to search gifs given by the argument in the search bar
//iteratively calls the dataCard function to populate search results
function search(offset){
    let argument = document.getElementById('argument').value;
    let total_count = offset * 20;
    fetch(`${API}/giphy/gifs/search/${argument}/${total_count}`)
        .then(response => {return response.json()})
        .then(data => {
            if(offset==0){
                document.getElementById('results').innerHTML = `
                <div class="row">
                    ${data.data.map(dataCard).join("")}
                </div>
                `
                document.getElementById('sidebar').innerHTML = ``
            }else{
                document.getElementById('results').innerHTML += `
                <div class="row">
                    ${data.data.map(dataCard).join("")}
                </div>
                `
            }
            if(data.pagination.total_count==0){
                document.getElementById('results').innerHTML = `<p class="text-center">No Results Found</p>`
            }
            if(data.pagination.total_count > (total_count + 20)){
                document.getElementById('more-results-button').innerHTML = `
                    <button type="button" class="btn btn-dark" onclick="search(${offset + 1})">More Results</button>
                `
            }else{
                document.getElementById('more-results-button').innerHTML = ``
            }
        })
        .catch(error => console.log(error))
}

//calls the API to return trending gifs
function trending(offset){
    document.getElementById('argument').value = 'trending';
    search(offset);
}