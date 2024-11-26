const GetDataFromUpDate = () => {

    Email = document.getElementById("updateEmail").value,
        Password = document.getElementById("updatePassword").value,
        FirstName = document.getElementById("updateFirstName").value,
        LastName = document.getElementById("updateLastName").value;

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
            //if status==400
            //week password
            //if !responsePut.ok
            //error

            alert("upDate successfully")
        }
    }
    catch (Error) {
        console.log('error:', Error)

    }


 
}





