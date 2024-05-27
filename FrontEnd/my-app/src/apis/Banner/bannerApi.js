import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";


const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const bannerApi = defineStore("banner", {
  actions: {
    createBanner(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post(
            "/Admin/CreateBanner",
            { ...params },
            {
              headers: {
                "Content-Type": "multipart/form-data",
                Authorization: `Bearer ${authorization}`,
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    deleteBanner(id) {
      return new Promise((resolve, reject) => {
        axiosIns
          .delete(`/user/XoaBanner/${id}`, {
            headers: {
              Authorization: `Bearer ${authorization}`,
            },
          })
          .then((res) => {
            if (res.status === 200) {
              // Sửa từ response thành res
              resolve(res.data);
            } else {
              reject(res); // Sử dụng res thay vì error
            }
          })
          .catch((error) => reject(error));
      });
    },
    getAllBanner() {
      return new Promise((resolve, reject) => {
        axiosIns
          .get("/User/GetAllBanners")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
            } else {
              reject(error);
            }
          })
          .catch((error) => reject(error));
      });
    },
  },
});
