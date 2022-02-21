<svelte:options tag="svelte-user-table" />
<script>
	
    const fetchData = (async () => {
		const response = await fetch('/api/User')
        console.log("Merhaba Dünya");
        return await response.json()
	})()
</script>


<main>        
    
            {#await fetchData}
                <p>...waiting</p>
                {:then data}
                <table border="1" class="table">
                    <thead>
                      <tr>
                        <th scope="col">#</th>
                        <th scope="col">Ad</th>
                        <th scope="col">Soyad</th>
                      </tr>
                    </thead>
                    <tbody>
                        {#each data as user, i}
                      <tr>
                        <th scope="row">{i+1}</th>
                        <td>{user.name}</td>
                        <td>{user.surname}}</td>
                      </tr>
                      {/each}

                    </tbody>
                  </table>

               
                    
                {:catch error}
                <p>An error occurred!</p>
            {/await}
</main>

