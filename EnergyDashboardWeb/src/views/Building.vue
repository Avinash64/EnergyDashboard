<script setup>





import { ref,reactive,  onMounted, computed, watch } from 'vue';
import { useRouter } from 'vue-router';
const router = useRouter()
const b_num = ref('0')
const building = reactive({})

onMounted(()=>{

	const options = {
		method: 'GET',
	};
	const {
		host, hostname, href, origin, pathname, port, protocol, search
	} = window.location
	console.log(href.split('/')[4])
	fetch(`http://localhost:5156/api/energy/${href.split('/')[4]}`, options)
	.then(response => response.json())
	.then(response => {console.log(response); building.value = response} )
	.catch(err => console.error(err));
	
})

// let token = localStorage.getItem('token')
const save = () => {
	const options = {
  method: 'PUT',
  headers: {
    'Content-Type': 'application/json',
	'Authorization': `Bearer ${localStorage.getItem('token')}`

  },
  body: JSON.stringify(building.value)
};

fetch('http://localhost:5156/api/energy', options)
  .then(response => response.status)
  .then(response => console.log(response))
  .catch(err => console.error(err));
  router.push('/buildings');
}

const remove = (bbl) => {
	const options = {
  method: 'DELETE',
};

fetch(`http://localhost:5156/api/energy/${bbl}/`, options)
  .then(response => response.status)
  .then(response => console.log(response))
  .catch(err => console.error(err));
}  


</script>


<template>
	
	<div class="buildingsPage">
		<h1>Building {{ $route.params.id }}</h1>
		<button >Add</button>
	<div v-if="building"  class="buildingForm">
		<div v-for="(value, key, index) in building.value" :key="index">
			<div class="form-group">
				<label :for="`${key}${index}`">{{ key.toUpperCase() }}:</label>
				<input type="text" class="form-control w-50" :id="`${key}${index}`" v-model="building.value[key]" :placeholder="value" >
			</div>
		</div>
	</div>
	
	<div class="options">
		<button type="button" @click="save()" class="btn btn-primary">Save</button>
		<button type="button" class="btn btn-secondary">Cancel</button>
		<button type="button" @click="remove(building.value.bbl)" class="btn btn-secondary">Cancel</button>
	</div>

	</div>
</template>


<style scoped>
.buildingForm {
	margin-left: 1rem;
}
.building_list_item {
	display: flex;
	flex-direction: row;
	align-items: center;
	justify-content: space-between;
	width: 100%;
	margin-bottom: 5px;
}

.field {
	width: 18%;
}

.buildingsPage {
	width: 100%;
}

.odd {
	background-color: aqua;
}
</style>
