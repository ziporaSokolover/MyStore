const level = document.getElementById("level");
level.value = 0;




const GetDataFromUpDate = () => {

    Email = document.getElementById("updateEmail").value,
        Password = document.getElementById("updatePassword").value,
        FirstName = document.getElementById("updateFirstName").value,
        LastName = document.getElementById("updateLastName").value;
    const level = document.querySelector("#level")
    const passwordScore = level.value

    if (Email.indexOf('@') == -1) {
        alert("Field Email must include @");
        return null;
    }
    else if (Email.indexOf('.') == -1) {
        alert("Field Email must include .");
        return null;
    }
    else if (passwordScore < 3) {
        alert("weak password")
        return null;
    }
    else if (FirstName.length < 2 || FirstName.length > 20 || LastName.length < 2 || LastName.length > 20) {
        alert("Name can be between 2 till 20 letters");
        return null;
    }
    else if (!Email || !Password || !FirstName || !LastName) {
        alert("All field are required");
        return null;
    }



    
    if (!Email || !Password || !FirstName || !LastName) { 
        alert("all fields are requierd")
    }
    else
        return ({ Email, Password, FirstName, LastName })
}

const update = async () => {
  
  
        try {
            const id = sessionStorage.getItem("id")
            const user = GetDataFromUpDate()
            if (user) {
                const responsePut = await fetch(`api/Users/${id}`, {
                    method: 'PUT',
                    headers: {
                        'content-Type': 'application/json'
                    },
                    body: JSON.stringify(user)
                });
                if (responsePut) {
                    alert("upDate successfully")
                    window.location.href = "Products.html"
                }
                else {
                    alert("upDate Not successfully")
                }
                
                
            }
        }
        catch (Error) {
            console.log('error:', Error)

        }
    }

    const getPassword = () => {
        const Password = document.getElementById("updatePassword").value;
        return Password;
    }


const cheakPassword = async () => {
    const password = getPassword();
    if (password) {
        try {
            const leavel = await fetch('api/Users/password', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                //fetch(`api/Users/login?email=${currentUser.Email}& password=${currentUser.Password}`, {
                //             method: "POST",
                //             headers: {
                //                 'Content-Type': 'application/json'
                //             },

                body: JSON.stringify(password)
            });


            const dataPost = await leavel.json();
            alert(dataPost);
            updateLevel(dataPost)
        }
        catch {
            console.log(err);



        }
    }
}
        const updateLevel = (dataPost) => {
            const level = document.querySelector("#level")
            level.value = dataPost


        }
    





