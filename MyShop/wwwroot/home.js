const level = document.getElementById("level");
level.value = 0;


const showRegister = () => {
    const register1 = document.querySelector(".register");
    register1.classList.remove("register");
}

const getUserDetailsFromHtml = () => {
  
    Email = document.getElementById("registerEmail").value,
        Password = document.getElementById("registerPassword").value,
        FirstName = document.getElementById("registerFirstName").value,
        LastName = document.getElementById("registerLastName").value,
    alert(Email);
    alert(Password);
   
    alert(FirstName);
    alert(LastName);
    return { Email, Password, FirstName, LastName };
}

const register = async () => {
   /* const newUser = getAllDetilesForSignUp();*/
    if (level.value < 3)
        alert("Password is too weak")
    else {
        try {
            const user = getUserDetailsFromHtml();
            if (user) {
                const registerPost = await fetch('api/Users', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },

                    body: JSON.stringify(user)
                }


                );
                const data = await registerPost.json()
                console.log(data)

            }
        }
        catch (Error) {
            console.log(Error);
        }
    }
}
    const currentUserDetailsFromHtml = () => {
        const Email = document.getElementById("loginEmail").value;
        const  Password = document.getElementById("loginPassword").value;
        return ({ Email, Password });
}
const getPassword = () => {
    const Password = document.getElementById("registerPassword").value;
    return  Password ;
}

const updateLevel = (dataPost) => {
    const level = document.querySelector("#level")
    level.value = dataPost


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

const Login = async () => {


        const currentUser = currentUserDetailsFromHtml();
        if (currentUser) {
            try {


                const loginPost = await fetch(`api/Users/Login?Email=${currentUser.Email}&password=${currentUser.Password}`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },


                    //fetch(`api/Users/login?email=${currentUser.Email}& password=${currentUser.Password}`, {
                    //             method: "POST",
                    //             headers: {
                    //                 'Content-Type': 'application/json'
                    //             },

                    query: { Email: currentUser.Email, Password: currentUser.Password }
                });

                if (!loginPost.ok)
                    throw new Error(`HTTP error! status:${loginPost.status}`);

                if (loginPost.status == 204)
                    alert("user not found")

                else {
                    const data = await loginPost.json();
                    console.log(data);

                    sessionStorage.setItem("id", data.userId)
                    window.location.href = "updateUser.html"
                }
            }
            catch (Error) {
                console.log(Error);


            }

        }
    }

