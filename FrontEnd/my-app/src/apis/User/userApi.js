import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";


const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const userApi = defineStore("user", {
  actions: {

    getUserId(id) {
      return new Promise((resolve, reject) => {
        axiosIns
          .get(`/Auth/GetUserById/${id}`)
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
            }else{
              reject(error)
            }
          })
          .catch((error) => reject(error));
      });
    },getAllUser() {
      return new Promise((resolve, reject) => {
        axiosIns
          .get("/User/GetAllUsers")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
            }else{
              reject(error)
            }
          })
          .catch((error) => reject(error));
      });
    },
  },
});
